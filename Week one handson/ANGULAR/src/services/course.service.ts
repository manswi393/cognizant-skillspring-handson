import { Injectable } from '@angular/core';
import { Course } from '../models/course.model';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  courses: Course[] = [
    {
      id: 1,
      title: 'Angular',
      duration: '2 Months',
      fee: 5000
    },
    {
      id: 2,
      title: 'Java',
      duration: '3 Months',
      fee: 7000
    }
  ];

  getCourses() {
    return this.courses;
  }
}