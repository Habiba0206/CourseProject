import React from 'react';
import './not-found.css';

const NotFoundPage = () => {
  return (
    <div className="not-found-container">
      <h1 className="not-found-title">Oops! Page Not Found</h1>
      <p className="not-found-message">
        Something went wrong. Please try again or go to another page.
      </p>
      <a href="/" className="not-found-button">Return to Home</a>
    </div>
  );
};

export default NotFoundPage;
