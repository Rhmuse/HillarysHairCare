import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
import "bootstrap/dist/css/bootstrap.css";
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { StylistList } from './components/stylist/StylistList';
import { AppointmentList } from './components/appointment/AppointmentList';
import { CustomerList } from './components/customer/CustomerList';
import { AppointmentForm } from './components/appointment/AppointmentForm';
import { CustomerForm } from './components/customer/CustomerForm';
import { StylistForm } from './components/stylist/StylistForm';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <BrowserRouter>
    <Routes>
      <Route path='/' element={<App />}>
        <Route index element={<AppointmentList />} />
        <Route path='stylists'>
          <Route index element={<StylistList />} />
          <Route path='create' element={<StylistForm />} />
        </Route>
        <Route path='appointments'>
          <Route index element={<AppointmentList />} />
          <Route path='create' element={<AppointmentForm />} />
        </Route>
        <Route path='customers'>
          <Route index element={<CustomerList />} />
          <Route path='create' element={<CustomerForm />} />
        </Route>
      </Route>
    </Routes>
  </BrowserRouter>
);

