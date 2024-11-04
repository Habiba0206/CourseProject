import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import axiosInstance from '../../api/axiosConfig';
import './templateStyles.css';

function TemplateList() {
  const [templates, setTemplates] = useState([]);
  const [loading, setLoading] = useState(true); 
  const [error, setError] = useState(null); 
  const navigate = useNavigate();

  useEffect(() => {
    const fetchTemplates = async () => {
      setLoading(true); // Start loading
      try {
        const response = await axiosInstance.get('/api/templates?TemplateFilter.PageSize=100&TemplateFilter.PageToken=1');
        setTemplates(response.data);
      } catch (error) {
        console.error('Failed to fetch templates:', error);
        setError('Failed to fetch templates. Please try again later.');
      } finally {
        setLoading(false); 
      }
    };

    fetchTemplates();
  }, []);

  const handleCreateTemplate = () => {
    navigate('/templates/create');
  };

  return (
    <div className="template-container">
      <h2 className="template-title">Available Templates</h2>

      {loading ? (
        <p>Loading templates...</p>
      ) : error ? (
        <p className="error-message">{error}</p>
      ) : templates.length > 0 ? (
        <ul>
          {templates.map((template) => (
            <li key={template.id} className="template-list-item">
              <strong>{template.title}</strong>: {template.description}
            </li>
          ))}
        </ul>
      ) : (
        <p>No templates available.</p>
      )}

      <button className="template-button" onClick={handleCreateTemplate}>
        Create Template
      </button>
    </div>
  );
}

export default TemplateList;
