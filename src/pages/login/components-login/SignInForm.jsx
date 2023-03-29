import React from "react";
import PersonIcon from "@mui/icons-material/People";
import LockIcon from "@mui/icons-material/Lock";
import FacebookIcon from '@mui/icons-material/Facebook';
import TwitterIcon from '@mui/icons-material/Twitter';
import GoogleIcon from '@mui/icons-material/Google';
import LinkedInIcon from '@mui/icons-material/LinkedIn';
// import "./css/signin.module.css";
export default function SignIn() {
  return (
    <form action="#" className="sign-in-form">
      <h2 className="title">Sign in</h2>
      <div className="input-field">
        <i>
          <PersonIcon />
        </i>
        <input type="text" placeholder="Username" />
      </div>
      <div className="input-field">
        <i className="fas fa-lock">
          <LockIcon />
        </i>
        <input type="password" placeholder="Password" />
      </div>
      <a href="#" className="social-text text-right">
        Forgot Password
      </a>
      <input type="submit" value="Login" className="btn solid" />
      <p className="social-text">Or Sign in with social platforms</p>
      <div className="social-media">
        <a href="#" className="social-icon">
          <i className="fab fa-facebook-f"><FacebookIcon/></i>
        </a>
        <a href="#" className="social-icon">
          <i className="fab fa-twitter"><TwitterIcon/></i>
        </a>
        <a href="#" className="social-icon">
          <i className="fab fa-google"><GoogleIcon/></i>
        </a>
        <a href="#" className="social-icon">
          <i className="fab fa-linkedin-in"><LinkedInIcon/></i>
        </a>
      </div>
    </form>
  );
}
