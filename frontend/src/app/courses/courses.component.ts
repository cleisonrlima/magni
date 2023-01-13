import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Course } from 'src/models/Course';
import { Student } from 'src/models/Student';
import { StudentService } from '../students/student.service';
import { CourseService } from './course.service';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent implements OnInit {

  public tittle = 'Cursos'
  public showGrades: boolean = false;
  public courses: Course[]
  public courseForm: FormGroup;
  public selectedCourse: Course | null;
  public students: Student[];
  public alerts: any = [
   
  ];

  constructor(private courseService: CourseService,private studentService: StudentService, private fb: FormBuilder) {
    this.createForm()
  }

  ngOnInit(): void {
    this.loadCourses();
  }


  loadCourses() {
    this.courseService.getAllCourses().subscribe(
      (courses: Course[]) => { this.courses = courses },
      (error: any) => { console.error(error) }
    )
  }

  createForm() {
    this.courseForm = this.fb.group({
      id: [''],
      name: ['', Validators.required],
    })
  }

  handleCourse(course: Course) {
    this.selectedCourse = course;
    this.courseForm.patchValue(course)
    this.alerts = []
    this.students = []
  }

  handleShowGrades(course: Course){
    this.selectedCourse = course;
    this.studentService.getStudentGradeByCourseId(course.id).subscribe(
      (stutents: Student[]) => {this.students = stutents}
    )
    this.showGrades = true;
  }

  back() {
    this.selectedCourse = null;
    this.students = []
    this.showGrades = false;
  }


  new(){
    this.selectedCourse = new Course();
    this.courseForm.patchValue(this.selectedCourse)
    this.alerts = [];
    this.showGrades = false;
  }

  save() {
    console.log(this.courseForm.getRawValue())
    this.courseService.saveOrUpdate(this.courseForm.getRawValue()).subscribe(
      () => { 
     this.alerts = [
      {
        type: 'success',
        msg: `<strong>OK!</strong> Salvo com sucesso!.`
      }
     ],
     this.loadCourses()
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


  getScoreMed(grades: any){
let tot = 0
    grades.map((g:any) => {
      tot = tot + g.score;
    })

    console.log(tot / grades.length)
    return (tot / grades.length).toFixed(2);
  }
}
