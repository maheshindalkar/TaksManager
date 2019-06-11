import { Component, OnInit } from '@angular/core';
import { Itask } from 'src/app/taskmodel/Itask';
import { TaskManagerService } from 'src/app/service/TaskManager.Service';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {
errorMessage = '';
  tasks : Itask[] =[];
  tasks1 : Itask[] =[];
  constructor(private taskmanagerService: TaskManagerService) {

  }

  ngOnInit(): void {
    this.taskmanagerService.getTaskManagerDetails().subscribe(
      taskList => {
        this.tasks = taskList;
      },
      error => this.errorMessage = <any>error
    );
  }
}
