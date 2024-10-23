import React, { useState } from 'react';
import axiosInstance from '../../api/axiosConfig';
import './authStyles.css';

function SignIn() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axiosInstance.post('/api/auth/sign-in', {
        emailAddress: email,
        password: password,
      });
      console.log('Signed in:', response.data);
    } catch (error) {
      console.error('Sign in failed:', error);
    }
  };

  return (
    <div className="auth-container">
      <h2 className="auth-title">Sign In</h2>
      <form onSubmit={handleSubmit}>
        <input
          type="email"
          placeholder="Email"
          className="auth-input"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
        />
        <input
          type="password"
          placeholder="Password"
          className="auth-input"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
        <button type="submit" className="auth-button">Sign In</button>
      </form>
    </div>
  );
}

export default SignIn;
