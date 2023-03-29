import React from "react";

export default function RightPanel({handleClick}) {
  return (
    <div className="content">
      <h3>One of us ?</h3>
      <p>
        Lorem ipsum dolor sit amet consectetur adipisicing elit. Nostrum
        laboriosam ad deleniti.
      </p>
      <button
        className="btn transparent"
        onClick={handleClick}
        id="sign-in-btn"
      >
        Sign in
      </button>
    </div>
  );
}
