import React, { useState } from "react";
import LeftPanel from "./components-login/LeftPanel.jsx";
import RightPanel from "./components-login/RightPanel.jsx";

import SignInForm from "./components-login/SignInForm.jsx";
import SignUpForm from "./components-login/SignUpForm";

import "./css-login/Login.module.css";


// import "./css-login/Login.module.css";
export default function Login() {
  const [signInUp, setSignInUp] = useState(false);
  function handleClick() {
    setSignInUp(!(signInUp))
  }
  return (
    <>
      <div className={signInUp ? "container sign-up-mode" : "container"}>
        <div className="forms-container">
          <div className="signin-signup">
            <SignInForm />
            <SignUpForm />
          </div>
        </div>

        <div className="panels-container">
          <LeftPanel handleClick = {handleClick}/>
          <div className="panel right-panel">
            <RightPanel handleClick={handleClick}/>
          </div>
        </div>
      </div>
    </>
  );
}
