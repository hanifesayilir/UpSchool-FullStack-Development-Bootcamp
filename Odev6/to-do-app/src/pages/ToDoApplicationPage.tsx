import React, { useState} from 'react';
import "./ToDoApplicationPage.css";
import {
    Button,
    Grid,
    Header,
    Icon,
    Input,
    Segment,
    Select,
    Card, GridColumn, GridRow, Item, List, Popup
} from "semantic-ui-react";

import ToDoModel from "../Models/ToDoModel";



const ToDoApplicationPage = () =>{

    const [toDo, setToDo] = useState<ToDoModel>({createdDate: undefined, id: "", isCompleted: false, task: ""})
    const [toDoList, setToDoList] = useState<ToDoModel[]>([]);
    const [addButtonStatus, setAddButtonStatus] =  useState<boolean>(true);
    const [selectedOrder, setSelectedOrder] = useState("true");

    const onAddButtonClick = () => {
        setToDoList([...toDoList, toDo]);
        setToDo({createdDate: undefined, id:  undefined, isCompleted: false, task: ""})
        setAddButtonStatus(true);
    };

    const options = [
        { key: "1", text: "Ascending", value: "true" },
        { key: "2", text: "Descending", value: "false" },
    ];

    const handleChangeInput = (event) => {
        event.preventDefault();
        if(event.target.value !== "") setAddButtonStatus(false);
        else setAddButtonStatus(true);
        setToDo({...toDo, task: event.target.value, id:crypto.randomUUID(), createdDate: new Date()});
    };

    const handleToDoItemDelete = (selectedItem: ToDoModel) => {
        const newToDoList = toDoList.filter(
            (item) => item.id !== selectedItem.id)
        setToDoList(newToDoList);
    }

    const handleChangeIsCompeted = (event, selectedItem: ToDoModel) => {
        if(event.detail === 2) {
            const inverseIsCompleted = !selectedItem.isCompleted
            const updatedToDoList = toDoList.map((item) => item.id === selectedItem.id ? {...item, isCompleted: inverseIsCompleted} : item);
            setToDoList(updatedToDoList);
        }
    }

    const handleSelectChange = (e, data) => {

        setSelectedOrder(data.value);
        if(data.value === "false") toDoList.sort((a, b) =>  (a.createdDate < b.createdDate ? 1 : -1));
        else toDoList.sort((a, b) => (a.createdDate > b.createdDate ? 1 : -1));
    };



        return(

        <Segment padded={"very"}>
            <Header as="h1" textAlign="center" className="main-header">
                My ToDo List
            </Header>
            <Grid padded={true}>
                <GridRow columns={2} >
                    <GridColumn  width={8} stretched={true}>
                        <Input
                            id={crypto.randomUUID()}
                            icon="tasks"
                            iconPosition={"left"}
                            placeholder="Please click here to add a task"
                            onChange={(e) =>handleChangeInput(e)}
                            size={"large"}
                            type={"text"}
                            value={toDo.task}
                        />
                    </GridColumn>
                    <GridColumn  width={4}>
                        <Popup trigger={<Button color="green" onClick={onAddButtonClick} disabled={addButtonStatus} size={"large"}><Icon name="add circle" /> Add</Button>}
                                            position="bottom left"
                                            style={{ color: "green"}}
                                            hideOnScroll
                                            > Click to Add</Popup>
                    </GridColumn>

                </GridRow>

            </Grid>

            <Grid padded={true} style={{ paddingTop: "30px" }}>
                <GridRow columns={2} >
                    <GridColumn  width={12} stretched={true}>
                        <Header as="h3" style={{ paddingBottom: "30px" }}>
                           Actual ToDos
                        </Header>
                    </GridColumn>
                    <GridColumn  width={4} stretched={true} >

                        <Select
                            className="ml-2"
                            placeholder="Select order"
                            options={options}
                            onChange={(e,  data) =>handleSelectChange(e, data)}
                            value={selectedOrder}

                        />
                    </GridColumn>
                </GridRow>
            </Grid>


                    <List bulleted divided verticalAlign={"middle"} ordered={true}>

                        { toDoList.map((item, index) =>
                            (<List.Item key={index}>

                                    <List.Content
                                        floated="left"
                                        verticalAlign={"middle"}
                                        onClick={(e) => handleChangeIsCompeted(e,item)}
                                        style={{textDecoration: item.isCompleted ? 'line-through' : 'none', color: item.isCompleted ? "red" : "black"}}
                                    >
                                        <Popup
                                            trigger={<div>{item.task}</div>}
                                            content={` Task name: ${item.task}, createdDate: ${item.createdDate}, IsCompleted: ${item.isCompleted}, `}
                                            style={{color: "green"}}
                                            header={item.task}
                                            key={item.id}
                                        />
                                    </List.Content>
                                    <List.Content floated="right" >
                                        <Popup trigger={<Button icon onClick={() => handleToDoItemDelete(item)}><Icon name="trash"color={"red"}/></Button>}
                                               position={"top right"}
                                               style={{ color: "red"}}
                                               hideOnScroll
                                        >Click To Delete</Popup>
                                    </List.Content >
                                </List.Item>
                            ))}
                    </List>

        </Segment>
    )

}
export default ToDoApplicationPage;
