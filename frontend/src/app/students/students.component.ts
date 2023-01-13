import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Course } from 'src/models/Course';
import { Student } from '../../models/Student';
import { CourseService } from '../courses/course.service';
import { StudentService } from './student.service';

@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent implements OnInit {

  public tittle = 'Alunos'
  public students: Student[]
  public studentForm: FormGroup;
  public selectedStudent: Student | null;
  public showGrades: boolean = false;
  public courses: Course[];
  public alerts: any = [
   
  ];

  constructor(private studentyService: StudentService, private courseService: CourseService, private fb: FormBuilder) {
    this.createForm()
  }

  ngOnInit(): void {
    this.loadStudents();
    this.loadCourses()
  }

  loadStudents() {
    this.studentyService.getAllStudents().subscribe(
      (students: Student[]) => { this.students = students },
      (error: any) => { console.error(error) }
    )
  }

  loadCourses() {
    this.courseService.getAllCourses().subscribe(
      (courses: Course[]) => { this.courses = courses },
      (error: any) => { console.error(error) }
    )
  }

  createForm() {
    this.studentForm = this.fb.group({
      id: [''],
      name: ['', Validators.required],
      registrationNumber: [{ value: '', disabled: true }, Validators.required],
      courseId: [''],
      
      birthDate: ['', Validators.required]
    })
  }

  handleStudent(student: Student) {
    this.selectedStudent = student;
    this.studentForm.patchValue(student)
    this.alerts = []
  }

  back() {
    this.selectedStudent = null;
    this.showGrades = false;
  }


  handleShowGrades(student: Student){
    this.selectedStudent = student;
    this.showGrades = true;
  }

  new(){
    this.selectedStudent = new Student();
    this.studentForm.patchValue(this.selectedStudent);
    this.alerts = [];
  }

  save() {
    console.log(this.studentForm.getRawValue())
    this.studentyService.saveOrUpdate(this.studentForm.getRawValue()).subscribe(
      () => { 
     this.alerts = [
      {
        type: 'success',
        msg: `<strong>OK!</strong> Salvo com sucesso!.`
      }
     ],
     this.loadStudents()
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
