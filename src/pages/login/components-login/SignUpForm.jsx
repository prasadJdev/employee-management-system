import React from "react";
import PersonIcon from "@mui/icons-material/People";
import LockIcon from "@mui/icons-material/Lock";
import FacebookIcon from "@mui/icons-material/Facebook";
import TwitterIcon from "@mui/icons-material/Twitter";
import GoogleIcon from "@mui/icons-material/Google";
import LinkedInIcon from "@mui/icons-material/LinkedIn";
import MailIcon from "@mui/icons-material/Mail";
import { Link } from "react-router-dom";
// import './css/signup.module.css'

export default function SignUpForm() {
  return (
    <form action="#" className="sign-up-form">
      <h2 className="title">Sign up</h2>
      <div className="input-field">
        <i className="fas fa-user">
          <PersonIcon />
        </i>
        <input type="text" placeholder="Username" />
      </div>
      <div className="input-field">
        <i className="fas fa-envelope">
          <MailIcon />
        </i>
        <input type="email" placeholder="Email" />
      </div>
      <div className="input-field">
        <i className="fas fa-lock">
          <LockIcon />
        </i>
        <input type="password" placeholder="Password" />
      </div>
      <Link to="/">
        <input type="submit" className="btn" value="Sign up" />
      </Link>

      <p className="social-text">Or Sign up with social platforms</p>
      <div className="social-media">
        <Link href="#" className="social-icon">
          <i className="fab fa-facebook-f">
            <FacebookIcon />
          </i>
        </Link>
        <Link href="#" className="social-icon">
          <i className="fab fa-twitter">
            <TwitterIcon />
          </i>
        </Link>
        <Link href="#" className="social-icon">
          <i className="fab fa-google">
            <GoogleIcon />
          </i>
        </Link>
        <Link href="#" className="social-icon">
          <i className="fab fa-linkedin-in">
            <LinkedInIcon />
          </i>
        </Link>
      </div>
    </form>
  );
}
