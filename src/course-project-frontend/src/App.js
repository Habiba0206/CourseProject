import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import SignIn from './components/Auth/SignIn';
import SignUp from './components/Auth/SignUp';
import CreateForm from './components/Forms/CreateForm';
import FormList from './components/Forms/FormList';
import CreateTemplate from './components/Templates/CreateTemplate';
import TemplateList from './components/Templates/TemplateList';
import AnswerForm from './components/Forms/AnswerForm';
import NotFound from './components/NotFound';
import './styles.css';

const App = () => {
    return (
        <Router>
            <div className="app-container">
                <Routes>
                    <Route path="/" element={<SignIn />} />
                    <Route path="/sign-up" element={<SignUp />} />
                    <Route path="/forms" element={<FormList />} />
                    <Route path="/forms/create" element={<CreateForm />} />
                    <Route path="/forms/:formId/answer" element={<AnswerForm />} />
                    <Route path="/templates" element={<TemplateList />} />
                    <Route path="/templates/create" element={<CreateTemplate />} />
                    <Route path="*" element={<NotFound />} />
                </Routes>
            </div>
        </Router>
    );
};

export default App;
