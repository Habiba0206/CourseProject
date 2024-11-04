import React, { useState } from 'react';
import axiosInstance from '../../api/axiosConfig';
import './formStyles.css';

function AnswerForm({ formId, questionId }) {
  const [answerValue, setAnswerValue] = useState('');
  const [errorMessage, setErrorMessage] = useState('');

  const handleAnswerSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axiosInstance.post('/api/answers', {
        formId: formId,
        questionId: questionId,
        value: answerValue,
      });
      console.log('Answer submitted:', response.data);
      setAnswerValue('');
    } catch (error) {
      console.error('Answer submission failed:', error);
      setErrorMessage('Answer submission failed. Please try again.');
    }
  };

  return (
    <div className="form-container">
      <h3 className="form-title">Submit Your Answer</h3>
      {errorMessage && <p className="error-message">{errorMessage}</p>}
      <form onSubmit={handleAnswerSubmit}>
        <input
          type="text"
          placeholder="Your answer"
          className="form-input"
          value={answerValue}
          onChange={(e) => setAnswerValue(e.target.value)}
        />
        <button type="submit" className="form-button">Submit Answer</button>
      </form>
    </div>
  );
}

export default AnswerForm;
