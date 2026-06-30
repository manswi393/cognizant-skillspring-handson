import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseService } from '../../../services/course.service';

@Component({
  selector: 'app-course-form',
  templateUrl: './course-form.component.html',
  styleUrls: ['./course-form.component.css']
})
export class CourseFormComponent implements OnInit {

  courseForm!: FormGroup;
  id: number | null = null;

  constructor(
    private fb: FormBuilder,
    private service: CourseService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.courseForm = this.fb.group({
      name: [''],
      description: [''],
      duration: ['']
    });

    this.id = Number(this.route.snapshot.paramMap.get('id'));

    if (this.id) {
      this.service.getCourse(this.id).subscribe(data => {
        this.courseForm.patchValue(data);
      });
    }
  }

  save() {
    if (this.id) {
      this.service.updateCourse(this.id, this.courseForm.value)
        .subscribe(() => this.router.navigate(['/courses']));
    } else {
      this.service.addCourse(this.courseForm.value)
        .subscribe(() => this.router.navigate(['/courses']));
    }
  }
}