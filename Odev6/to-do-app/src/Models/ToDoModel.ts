import React, {Component} from 'react';
import DateTimeFormat = Intl.DateTimeFormat;

class ToDoModel  {
    id: string| undefined;

    task: string;

    isCompleted: boolean;

    createdDate: Date | undefined;


    constructor(id: string | undefined, task: string, isCompleted: boolean, createdDate: Date | undefined) {
        this.id = id;
        this.task = task;
        this.isCompleted = isCompleted;
        this.createdDate = createdDate;
    }
}

export default ToDoModel;
