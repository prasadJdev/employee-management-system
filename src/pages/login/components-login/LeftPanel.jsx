import React from "react";

export default function LeftPanel({handleClick}) {
  return (
    <div className="panel left-panel">
      <div className="content">
        <h3>New here ?</h3>
        <p>
          Lorem ipsum, dolor sit amet consectetur adipisicing elit. Debitis, ex
          ratione. Aliquid!
        </p>
        <button
          className="btn transparent"
          onClick={handleClick}
          id="sign-up-btn"
        >
          Sign up
        </button>
      </div>
    </div>
  );
}
