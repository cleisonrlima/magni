import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Discipline } from 'src/models/Discipline';
import { DisciplineService } from './discipline.service';

@Component({
  selector: 'app-disciplines',
  templateUrl: './disciplines.component.html',
  styleUrls: ['./disciplines.component.css']
})
export class DisciplinesComponent implements OnInit {

  public tittle = 'Disciplinas'
  public disciplines: Discipline[]
  public disciplineForm: FormGroup;
  public selectedDiscipline: Discipline | null;
  public showGrades: boolean = false;
  public alerts: any = [
   
  ];

  constructor(private disciplineService: DisciplineService, private fb: FormBuilder) {
    this.createForm()
  }

  ngOnInit(): void {
    this.loadDisciplies();
  }


  loadDisciplies() {
    this.disciplineService.getAllDisciplines().subscribe(
      (disciplines: Discipline[]) => { this.disciplines = disciplines },
      (error: any) => { console.error(error) }
    )
  }

  createForm() {
    this.disciplineForm = this.fb.group({
      id: [''],
      name: ['', Validators.required],
    })
  }

  handleDiscipline(discipline: Discipline) {
    this.selectedDiscipline = discipline;
    this.disciplineForm.patchValue(discipline)
    this.alerts = []
  }


  handleShowGrades(discipline: Discipline){
    this.disciplineService.getDisciplineById(discipline.id).subscribe(
      (discipline: Discipline) => { this.selectedDiscipline = discipline},
      (error: any) => { console.error(error) }
    )
    this.showGrades = true;
  }


  back() {
    this.selectedDiscipline = null;
    this.showGrades = false;
  }


  new(){
    this.selectedDiscipline = new Discipline();
    this.disciplineForm.patchValue(this.selectedDiscipline);
    this.alerts = []
  }

  save() {
    console.log(this.disciplineForm.getRawValue())
    this.disciplineService.saveOrUpdate(this.disciplineForm.getRawValue()).subscribe(
      () => { 
     this.alerts = [
      {
        type: 'success',
        msg: `<strong>OK!</strong> Salvo com sucesso!.`
      }
     ],
     this.loadDisciplies()
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
