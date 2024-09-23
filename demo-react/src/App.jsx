import { useEffect, useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import api from './config/axios'
import { RouterProvider, createBrowserRouter } from 'react-router-dom'
import Dashboard from './components/dashboard'
import ManageCategory from './pages/category'
import ManageProduct from './pages/product'

function App() {
  const router = createBrowserRouter([
    {
      path: "",
      element: <Dashboard />,
      children: [
        {
          path: "category",
          element: <ManageCategory />,
        },
        {
          path: "product",
          element: <ManageProduct />,
        },
      ],
    },
  ]);

  return <RouterProvider router={router} />;
}

export default App
