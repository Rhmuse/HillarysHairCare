import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
import "bootstrap/dist/css/bootstrap.css";
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import { StylistList } from './components/stylist/StylistList';
import { AppointmentList } from './components/appointment/AppointmentList';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <BrowserRouter>
    <Routes>
      <Route path='/' element={<App />}>
        <Route path='stylists'>
          <Route index element={<StylistList />} />
        </Route>
        <Route path='appointments'>
          <Route index element={<AppointmentList />} />
        </Route>
      </Route>
    </Routes>
  </BrowserRouter>
);

