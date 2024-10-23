import React, { useState } from 'react';
import axiosInstance from '../../api/axiosConfig';
import './formStyles.css';

function AnswerForm({ formId, questionId }) {
  const [answerValue, setAnswerValue] = useState('');

  const handleAnswerSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axiosInstance.post('/api/answers', {
        formId: formId,
        questionId: questionId,
        value: answerValue,
      });
      console.log('Answer submitted:', response.data);
      setAnswerValue('');  // Clear input after submission
    } catch (error) {
      console.error('Answer submission failed:', error);
    }
  };

  return (
    <div className="form-container">
      <h3 className="form-title">Submit Your Answer</h3>
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
