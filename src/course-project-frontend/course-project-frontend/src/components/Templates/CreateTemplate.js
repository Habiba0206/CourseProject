import React, { useState } from 'react';
import axiosInstance from '../../api/axiosConfig';
import './templateStyles.css';
import { useNavigate } from 'react-router-dom';
import Template from '../../models/Template'; 

function CreateTemplate() {
  const [templateTitle, setTemplateTitle] = useState('');
  const [templateDescription, setTemplateDescription] = useState('');
  const [errorMessage, setErrorMessage] = useState('');
  const navigate = useNavigate();

  const handleTemplateSubmit = async (e) => {
    e.preventDefault();
    const newTemplate = new Template(null, templateTitle, templateDescription, true); 
    try {
      const response = await axiosInstance.post('/api/templates', {
        title: newTemplate.title,
        description: newTemplate.description,
        isPublic: newTemplate.isPublic,
      });
      console.log('Template created:', response.data);
      setTemplateTitle('');
      setTemplateDescription('');
      navigate('/templates');
    } catch (error) {
      console.error('Template creation failed:', error);
      setErrorMessage('Template creation failed. Please try again.');
      if (error.response) {
        console.error('Error response:', error.response.data);
      } else if (error.request) {
        console.error('No response received:', error.request);
      } else {
        console.error('Error message:', error.message);
      }
    }
  };

  return (
    <div className="template-container">
      <h2 className="template-title">Create a New Template</h2>
      {errorMessage && <p className="error-message">{errorMessage}</p>}
      <form onSubmit={handleTemplateSubmit}>
        <input
          type="text"
          placeholder="Template Title"
          className="template-input"
          value={templateTitle}
          onChange={(e) => setTemplateTitle(e.target.value)}
          required
        />
        <textarea
          placeholder="Template Description"
          className="template-input"
          value={templateDescription}
          onChange={(e) => setTemplateDescription(e.target.value)}
          required
        />
        <button type="submit" className="template-button">Create Template</button>
      </form>
    </div>
  );
}

export default CreateTemplate;
