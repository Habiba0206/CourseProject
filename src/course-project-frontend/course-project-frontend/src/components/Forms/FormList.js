import React, { useState, useEffect } from 'react';
import axiosInstance from '../../api/axiosConfig';
import './formStyles.css';

function FormList() {
  const [forms, setForms] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');

  useEffect(() => {
    const fetchForms = async () => {
      try {
        const response = await axiosInstance.get('/api/forms?FormFilter.PageSize=100&FormFilter.PageToken=1');
        setForms(response.data);
      } catch (error) {
        console.error('Failed to fetch forms:', error);
        setError('Failed to fetch forms. Please try again later.');
      } finally {
        setLoading(false);
      }
    };

    fetchForms();
  }, []);

  return (
    <div className="form-container">
      <h2 className="form-title">Available Forms</h2>
      {loading && <p>Loading forms...</p>}
      {error && <p className="error-message">{error}</p>}
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
