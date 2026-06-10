import { Routes } from '@angular/router';
import { Records } from './pages/records/records';
import { Dashboard } from './pages/dashboard/dashboard';
import { Chat } from './pages/chat/chat';
import { RecordForm } from './pages/record-form/record-form';

export const routes: Routes = [
  {
    path: '',
    component: Dashboard
  },
  
  {
    path: 'records',
    component: Records
  },
  {
    path: 'create',
    component: RecordForm
  },
  {
    path: 'edit/:id',
    component: RecordForm
    },
  {
    path: 'chat',
    component: Chat
  }
  
];