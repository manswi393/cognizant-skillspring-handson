import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';

import { CourseListComponent } from './components/course/course-list/course-list.component';
import { CourseDetailComponent } from './components/course/course-detail/course-detail.component';
import { CourseFormComponent } from './components/course/course-form/course-form.component';

const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },

  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },

  { path: 'courses', component: CourseListComponent },
  { path: 'courses/add', component: CourseFormComponent },
  { path: 'courses/edit/:id', component: CourseFormComponent },
  { path: 'courses/:id', component: CourseDetailComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }