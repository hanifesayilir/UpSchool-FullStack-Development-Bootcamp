import React, {Component} from 'react';
import DateTimeFormat = Intl.DateTimeFormat;

class ToDoModel  {
    id: number | undefined;

    task: string;

    isCompleted: boolean;

    createdDate: Date | undefined;


    constructor(id: number, task: string, isCompleted: boolean, createdDate: Date) {
        this.id = id;
        this.task = task;
        this.isCompleted = isCompleted;
        this.createdDate = createdDate;
    }
}

export default ToDoModel;
