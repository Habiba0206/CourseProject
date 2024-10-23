import React, { useState, useEffect } from 'react';
import axiosInstance from '../../api/axiosConfig';
import './formStyles.css';

function FormList() {
  const [forms, setForms] = useState([]);

  useEffect(() => {
    const fetchForms = async () => {
      try {
        const response = await axiosInstance.get('/api/forms');
        setForms(response.data);
      } catch (error) {
        console.error('Failed to fetch forms:', error);
      }
    };

    fetchForms();
  }, []);

  return (
    <div className="form-container">
      <h2 className="form-title">Available Forms</h2>
      <ul>
        {forms.map((form) => (
          <li key={form.id} className="form-list-item">
            {form.title}: {form.description}
          </li>
        ))}
      </ul>
    </div>
  );
}

export default FormList;
