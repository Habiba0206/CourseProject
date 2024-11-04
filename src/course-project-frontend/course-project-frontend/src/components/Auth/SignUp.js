import React, { useState } from 'react';
import axiosInstance from '../../api/axiosConfig';
import { useNavigate } from 'react-router-dom';
import './authStyles.css';

function SignUp() {
  const [formData, setFormData] = useState({
    firstName: '',
    lastName: '',
    email: '',
    age: '',
    password: '',
  });

  const navigate = useNavigate(); // Hook for navigation

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axiosInstance.post('/api/auth/sign-up', {
        firstName: formData.firstName,
        lastName: formData.lastName,
        emailAddress: formData.email,
        age: parseInt(formData.age),
        password: formData.password,
      });
      console.log('Signed up:', response.data);

      // Navigate to the template list page after successful sign up
      navigate('/templates'); 
    } catch (error) {
      console.error('Sign up failed:', error);
    }
  };

  return (
    <div className="auth-container">
      <h2 className="auth-title">Sign Up</h2>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          placeholder="First Name"
          className="auth-input"
          name="firstName"
          value={formData.firstName}
          onChange={handleChange}
        />
        <input
          type="text"
          placeholder="Last Name"
          className="auth-input"
          name="lastName"
          value={formData.lastName}
          onChange={handleChange}
        />
        <input
          type="email"
          placeholder="Email"
          className="auth-input"
          name="email"
          value={formData.email}
          onChange={handleChange}
        />
        <input
          type="number"
          placeholder="Age"
          className="auth-input"
          name="age"
          value={formData.age}
          onChange={handleChange}
        />
        <input
          type="password"
          placeholder="Password"
          className="auth-input"
          name="password"
          value={formData.password}
          onChange={handleChange}
        />
        <button type="submit" className="auth-button">Sign Up</button>
      </form>
    </div>
  );
}

export default SignUp;
