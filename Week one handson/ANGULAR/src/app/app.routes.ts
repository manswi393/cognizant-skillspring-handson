import { Routes } from '@angular/router';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { CourseListComponent } from './components/course/course-list/course-list.component';

export const routes: Routes = [
  { path: '', redirectTo: 'courses', pathMatch: 'full' },

  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },

  { path: 'courses', component: CourseListComponent }
];