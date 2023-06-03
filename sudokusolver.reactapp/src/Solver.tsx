import { useState } from "react"
import { SudokuAnalysisResponse } from "./models/SudokuAnalyticsResponse";
import {callSolve} from './services/Api'

export function Solver(){
    const [input, setInput] = useState('')
    const [response, setResponse] = useState(new SudokuAnalysisResponse());

    return (
        
        <div>
            <h1>Sudoku Solver</h1>
            <main>
                <h3>Welcome to the sudoku solver!</h3>
                <p>
                    Place a string of 81 numbers into the text area below.  This will be parsed as "Every 9 numbers is a row, starting from the top"
                </p>
            </main>
            <div>

            <textarea
                onChange={
                    (e)=> {
                        setInput(e.target.value)
                        console.log(input);
                    }
                }
                />
            <button 
                type='button'
                onClick={async (e)=>{
                    let result: any = await callSolve(input);
                    let hardResponse: SudokuAnalysisResponse = result.data.data;
                    setResponse(hardResponse);
                }}
                >
                    Solve
                </button>
                <div>
                    Total Passes = {response.totalPasses}
                </div>
            </div>
        </div>
    );
}