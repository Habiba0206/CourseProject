import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom'; // Import useNavigate
import axiosInstance from '../../api/axiosConfig';
import './templateStyles.css';

function TemplateList() {
  const [templates, setTemplates] = useState([]);
  const navigate = useNavigate(); // Initialize navigate

  useEffect(() => {
    const fetchTemplates = async () => {
      try {
        const response = await axiosInstance.get('/api/templates');
        setTemplates(response.data);
      } catch (error) {
        console.error('Failed to fetch templates:', error);
      }
    };

    fetchTemplates();
  }, []);

  const handleCreateTemplate = () => {
    navigate('/templates/create'); // Navigate to create template page
  };

  return (
    <div className="template-container">
      <h2 className="template-title">Available Templates</h2>
      <ul>
        {templates.map((template) => (
          <li key={template.id} className="template-list-item">
            {template.title}: {template.description}
          </li>
        ))}
      </ul>
      <button className="create-template-button" onClick={handleCreateTemplate}>
        Create Template
      </button>
    </div>
  );
}

export default TemplateList;
