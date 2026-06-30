import { Injectable } from '@angular/core';
import { Student } from '../models/student.model';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  students: Student[] = [
    {
      id: 1,
      name: 'John',
      email: 'john@gmail.com',
      course: 'Angular'
    },
    {
      id: 2,
      name: 'Alice',
      email: 'alice@gmail.com',
      course: 'Java'
    }
  ];

  getStudents() {
    return this.students;
  }

  addStudent(student: Student) {
    this.students.push(student);
  }
}