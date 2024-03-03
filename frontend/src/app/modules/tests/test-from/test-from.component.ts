import { Component } from '@angular/core';

type Question = {
  text:string
}

type CustomType = {
  title:string,
  text: string,
  questions:Question[]
}

@Component({
  selector: 'app-test-from',
  templateUrl: './test-from.component.html',
  styleUrls: ['./test-from.component.scss']
})
export class TestFromComponent {

  value:string;

  public question:CustomType =
    {
      title: "test1",
      text: "about zebra",
      questions:[
        {
          text: "white"
        },
        {
          text: "black"
        },
        {
          text: "yellow"
        },
        {
          text: "green"
        }
      ]
    }

    RetrieveAnswer(){

    }
    OnItemChange(e: Event){
      this.value = (e.target as HTMLInputElement).getAttribute('name') || '';
    }
}
