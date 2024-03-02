import { Component } from "@angular/core";
import {ActivatedRoute, Router} from '@angular/router';

type OptionType = {
  name:string,
  isVerified:boolean
}

@Component({
    selector: 'app-students-page',
    templateUrl: 'students.component.html',
    styleUrls: ['students.component.scss'],
})
export class StudentsPageComponent {
  students: OptionType[]=[
    {
      name: "student",
      isVerified:false
    }
  ]


  constructor(private router: Router, private route: ActivatedRoute) {
  }

  public Verify(name:string){//TODO refactor for backend request
    let student = this.students.find(s=>s.name == name)
    if(student)
      student.isVerified = true;
  }

  public Deny(name:string){
    //TODO delete
  }

  public NavigateToStudentPage(){
    this.router.navigate(['2'], { relativeTo: this.route })
  }
}
