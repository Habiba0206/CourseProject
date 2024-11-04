import React, { useState } from 'react';
import axiosInstance from '../../api/axiosConfig';
import './formStyles.css';

function CreateForm() {
  const [formTitle, setFormTitle] = useState('');
  const [formDescription, setFormDescription] = useState('');
  const [errorMessage, setErrorMessage] = useState('');

  const handleFormSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axiosInstance.post('/api/forms', {
        title: formTitle,
        description: formDescription,
      });
      console.log('Form created:', response.data);
      setFormTitle('');
      setFormDescription('');
    } catch (error) {
      console.error('Form creation failed:', error);
      setErrorMessage('Form creation failed. Please try again.');
    }
  };

  return (
    <div className="form-container">
      <h2 className="form-title">Create a New Form</h2>
      {errorMessage && <p className="error-message">{errorMessage}</p>}
      <form onSubmit={handleFormSubmit}>
        <input
          type="text"
          placeholder="Form Title"
          className="form-input"
          value={formTitle}
          onChange={(e) => setFormTitle(e.target.value)}
        />
        <textarea
          placeholder="Form Description"
          className="form-input"
          value={formDescription}
          onChange={(e) => setFormDescription(e.target.value)}
        />
        <button type="submit" className="form-button">Create Form</button>
      </form>
    </div>
  );
}

export default CreateForm;
