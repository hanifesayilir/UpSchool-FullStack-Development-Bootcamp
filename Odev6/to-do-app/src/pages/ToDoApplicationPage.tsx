import React, {useState} from 'react';
import "./ToDoApplicationPage.css";
import {
    Button,
    Divider,
    Grid,
    Header,
    Icon,
    Input,
    Segment,
    Select,
    Card, GridColumn, GridRow, Item,List
} from "semantic-ui-react";
import {toast} from "react-toastify";
import ToDoModel from "../Models/ToDoModel";
import DateTimeFormat = Intl.DateTimeFormat;
import {Simulate} from "react-dom/test-utils";
import toggle = Simulate.toggle;
import cqb = CSS.cqb;
import {Link} from "react-router-dom";



const ToDoApplicationPage = () =>{

    const [toDo, setToDo] = useState<ToDoModel>({createdDate: undefined, id: "", isCompleted: false, task: ""})
    const [toDoList, setToDoList] = useState<ToDoModel[]>([]);
    const [addButtonStatus, setAddButtonStatus] =  useState<boolean>(true);
    const [selectedOrder, setSelectedOrder] = useState();

    const onAddButtonClick = (e) => {
        console.log("deneme", e.target.event);
        setToDoList([...toDoList, toDo]);
        setToDo({createdDate: undefined, id:  undefined, isCompleted: false, task: ""})
    };

    const updateState = (key: string | number, recentValue: any) => {
        setToDo({ ...toDo, [key]: recentValue });
    };

    const options = [
        { key: "1", text: "Ascending", value: "true" },
        { key: "2", text: "Descending", value: "false" },
    ];

    const handleChangeInput = (event) => {
        event.preventDefault();
        setAddButtonStatus(false);
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
        console.log("Select option changed");
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
                            placeholder="Task"
                            onChange={(e) =>handleChangeInput(e)}
                            size={"large"}
                            type={"text"}
                            value={toDo.task}
                        />
                    </GridColumn>
                    <GridColumn  width={4}>
                        <Button color="green"
                                onClick={onAddButtonClick}
                                disabled={addButtonStatus}
                                size={"large"}
                        >
                            <Icon name="add circle" /> Add
                        </Button>

                    </GridColumn>

                </GridRow>

            </Grid>

            <Grid padded={true} style={{ paddingTop: "30px" }}>
                <GridRow columns={2} >
                    <GridColumn  width={4} stretched={true}>
                        <Header as="h3" style={{ paddingBottom: "30px" }}>
                           Actual ToDos
                        </Header>
                    </GridColumn>
                    <GridColumn  width={4} stretched={true} >

                        <Select
                            className="ml-2"
                            placeholder="Select order"
                            options={options}
                            onChange={(e, data) =>handleSelectChange(e, data)}
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
                                        style={{textDecoration: item.isCompleted ? 'line-through' : 'none'}}
                                    >
                                        {item.task}
                                    </List.Content>
                                    <List.Content floated="right" >
                                        <Button icon onClick={() => handleToDoItemDelete(item)}>
                                            <Icon name="trash"/>
                                        </Button>
                                    </List.Content >
                                </List.Item>
                            ))}
                    </List>

        </Segment>
    )

}
export default ToDoApplicationPage;
