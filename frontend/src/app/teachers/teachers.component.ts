import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Teacher } from 'src/models/Teacher';
import { TeacherService } from './teacher.service';

@Component({
  selector: 'app-teachers',
  templateUrl: './teachers.component.html',
  styleUrls: ['./teachers.component.css']
})
export class TeachersComponent implements OnInit {

  public tittle = 'Professores'
  public teachers: Teacher[]
  public teacherForm: FormGroup;
  public selectedTeacher: Teacher | null;
  public alerts: any = [
   
  ];

  constructor(private teacherService: TeacherService, private fb: FormBuilder) {
    this.createForm()
  }

  ngOnInit(): void {
    this.loadTeachers();
  }


  loadTeachers() {
    this.teacherService.getAllTeachers().subscribe(
      (teachers: Teacher[]) => { this.teachers = teachers },
      (error: any) => { console.error(error) }
    )
  }

  createForm() {
    this.teacherForm = this.fb.group({
      id: [''],
      name: ['', Validators.required],
      birthDate: ['', Validators.required],
      salaryAmount: ['', Validators.required],
    })
  }

  handleTeacher(teacher: Teacher) {
    this.selectedTeacher = teacher;
    this.teacherForm.patchValue(teacher)
    this.alerts = []
  }

  back() {
    this.selectedTeacher = null;
  }


  new(){
    this.selectedTeacher = new Teacher();
    this.teacherForm.patchValue(this.selectedTeacher);
    this.alerts = []
  }

  save() {
    console.log(this.teacherForm.getRawValue())
    this.teacherService.saveOrUpdate(this.teacherForm.getRawValue()).subscribe(
      () => { 
     this.alerts = [
      {
        type: 'success',
        msg: `<strong>OK!</strong> Salvo com sucesso!.`
      }
     ],
     this.loadTeachers()
      },
      (error) => { console.error(error),
        this.alerts = [
          {
            type: 'info',
            msg: `<strong>ops!</strong> ${error}`
          }
         ]
      }
    )
  }
}
