import React, { useState } from 'react'
import './App.css'
import {ToastContainer} from "react-toastify";
import {Container} from "semantic-ui-react";
import { Routes, Route} from  "react-router-dom"
import ToDoApplicationPage from "./pages/ToDoApplicationPage";
import NavBar from "./components/NavBar";
import NotFoundPage from "./pages/NotFoundPage";

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <ToastContainer />
      <NavBar />
      <Container className="App">
        <Routes>
          <Route path="/" element={<ToDoApplicationPage />}/>
            <Route path="*" element={<NotFoundPage />} />
        </Routes>
      </Container>
    </>
  )
}

export default App
