import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  pageTitle:string="Add Task";
  constructor() { }

  ngOnInit() {
  }

}
