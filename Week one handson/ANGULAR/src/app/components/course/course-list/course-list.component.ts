import { Component, OnInit } from '@angular/core';
import { CourseService, Course } from '../../../services/course.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.css']
})
export class CourseListComponent implements OnInit {

  courses: Course[] = [];

  constructor(private service: CourseService, private router: Router) {}

  ngOnInit(): void {
    this.loadCourses();
  }

  loadCourses() {
    this.service.getCourses().subscribe(data => {
      this.courses = data;
    });
  }

  viewCourse(id: number) {
    this.router.navigate(['/courses', id]);
  }

  editCourse(id: number) {
    this.router.navigate(['/courses/edit', id]);
  }

  deleteCourse(id: number) {
    this.service.deleteCourse(id).subscribe(() => {
      this.loadCourses();
    });
  }
}