import React from 'react'
import "../Component/calculator.css"

const Calculator = () => {
    var screen = document.querySelector('#screen');
    var btn = document.querySelectorAll('.btn');

    const clickHandler = e =>{
        var dot
        var btntext = e.target.innerText
        var check = screen.value
        let key = true
        for (let index = 0; index <= check.length; index++) {
            if (check.charAt(index) == dot) {
                key = false
            }
        }
        if(btntext == '.' && key){
             dot = btntext
        }
        if (key ) {
            screen.value += btntext
        }
    }
    const resetClick = ()=>{
        screen.value =""
    }

    const backClick = () =>{
        screen.value = screen.value.substr(0,screen.value.length-1)
    }

    const elvaClick = () =>{
        screen.value = eval(screen.value)
    }

    const sinClick = () =>{
        screen.value = Math.sin(screen.value)
    }

    const cosClick = () =>{
        screen.value = Math.cos(screen.value)
    }

    const tanClick = () =>{
        screen.value = Math.tan(screen.value) 
    }

    const pieClick = ()=>{
        screen.value = 3.14
    }

    const eClick = () =>{
        screen.value = Math.exp(screen.value)
    }

    const logClick = () =>{
        screen.value = Math.log(screen.value)
    }

    const sqrt = () =>{
        screen.value = Math.sqrt(screen.value)
    }

    const fact = () =>{
        var num,factorial = 1,i=1
        num = screen.value

        while(num!=0){
            factorial = factorial * i
            i++
            num--
        }
        screen.value = factorial;
    }

    const power = () =>{
        screen.value = Math.pow(screen.value,2)
    }
  
  return (
    <>
    <center>
        <div className="mainScreen">
            <p >
                Scientific-Calculator
            </p>
            <div className="diplayScreen">
                <input id='screen'  type="text" />
            </div>

            <div className="buttonPad">
                <button className='btn' id='back'  onClick={backClick}> back </button>  
                <button className='btn' onClick={pieClick}> &pi; </button> 
                <button className='btn' onClick={eClick}> e </button>   
                <button className='btn' onClick={logClick}> log </button>  
                <button className='btn' id='AC' type='reset' onClick={resetClick}>  AC </button>  <br></br>
            </div>
            <div className="buttonPad">
                <button className='btn' > ln </button>  
                <button className='btn' onClick={sqrt} > &radic; </button>  
                <button className='btn' onClick={power} > x<sup> 2 </sup> </button> 
                <button className='btn' onClick={clickHandler} > ( </button>   
                <button className='btn' onClick={clickHandler} > ) </button>  
                <br></br>
            </div>
            <div className="buttonPad">
                <button className='btn' onClick={fact} > X! </button>  
                <button className='btn' onClick={tanClick} > tan() </button>  
                <button className='btn' onClick={cosClick} > cos() </button> 
                <button className='btn' onClick={sinClick} > sin() </button>   
                <button className='btn' onClick={clickHandler} > . </button>  
                <br></br>
            </div>
            <div className="buttonPad">
                <button className='btn' onClick={clickHandler}> 7 </button>  
                <button className='btn' onClick={clickHandler}> 8 </button>  
                <button className='btn' onClick={clickHandler}> 9 </button> 
                <button className='btn' onClick={clickHandler}> / </button>   
                <button className='btn' onClick={clickHandler}> % </button>  
                 <br></br>
            </div>
            <div className="buttonPad">
                <button className='btn' onClick={clickHandler} > 4 </button>  
                <button className='btn' onClick={clickHandler} > 5 </button>  
                <button className='btn' onClick={clickHandler} > 6 </button> 
                <button className='btn' onClick={clickHandler} > + </button>   
                <button className='btn' onClick={clickHandler} > - </button>  
                 <br></br>
            </div>
            <div className="buttonPad">
                <button className='btn' onClick={clickHandler} > 1 </button>  
                <button className='btn' onClick={clickHandler} > 2 </button>  
                <button className='btn' onClick={clickHandler} > 3 </button> 
                <button className='btn' onClick={clickHandler} > 0 </button>   
                <button className='btn' id='Ans' onClick={elvaClick} > = </button>  
                  <br></br>
            </div>
        </div>
        </center>
    </>
  )
}

export default Calculator