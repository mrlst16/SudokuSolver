import { useState } from "react"
import { SudokuAnalyticsResponse } from "./models/SudokuAnalyticsResponse";
import {callParse, callSolve} from './services/Api'
import "./styles/Solver.css"
import "./styles/Button.css"
import Puzzle from "./components/Puzzle";
import { ApiError } from "./models/ApiError";
import ErrorDisplay from "./components/ErrorDisplay";
import { ApiErrors } from "./models/ApiErrors";
import { ParserResponse } from "./models/ParserResponse";
import MovesTable from "./components/MovesTable";

export function Solver(){
    const [input, setInput] = useState('')
    const [response, setResponse] = useState(new SudokuAnalyticsResponse());
    const [parsedPuzzle, setparsedPuzzle] = useState(new ParserResponse());
    const [errors, setErrors] = useState(new ApiErrors());

    function HandleInputChange(e: React.ChangeEvent<HTMLTextAreaElement>){
        console.log("e");
        console.log(e);
        setInput(e.target.value);
        setResponse(new SudokuAnalyticsResponse());
        callParse(e.target.value)
            .then(x=> {
                console.log("x");
                console.log(x);
                setparsedPuzzle(x.data.data)
                console.log("parsedPuzzle");
                console.log(parsedPuzzle);
                console.log(parsedPuzzle.board);
            })
            .catch(er=> {
                console.log("er");
                console.log(er);
                setparsedPuzzle(new ParserResponse())
            });
    }
    
    function HandleSolveButtonClick(){
        setResponse(new SudokuAnalyticsResponse());
        callSolve(input)
                .then(x=> {
                    setResponse(x.data.data)
                    setErrors(new ApiErrors())
                })
                .catch(e=> {
                    setResponse(new SudokuAnalyticsResponse());
                    let errorsArray: ApiError [] = e.response.data.Errors;
                    let apiErrors: ApiErrors = new ApiErrors()
                    apiErrors.Errors = errorsArray
                    setErrors(apiErrors);
                });
    }
    
    return (
        <div className="solver">
            <h1>Sudoku Solver</h1>
            <main>
                <h3>Welcome to the sudoku solver!</h3>
                <p>
                    Place a string of 81 numbers into the text area below.
                </p>
                <p>
                    This will be parsed as "Every 9 numbers is a row, starting from the top"
                </p>
            </main>
            <div>
            <table className="formTable">
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    <textarea
                                        className="input"                
                                        onChange={async x=> {
                                                console.log("input");
                                                console.log(input); 
                                                HandleInputChange(x);
                                            }
                                        }
                                    />
                                </td>
                                <td>
                                    <Puzzle Grid={parsedPuzzle.board} FontSize={12.75} />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <button 
                            className="button-3"
                            type='button'
                            onClick={HandleSolveButtonClick}
                        >
                            Solve
                        </button>
                    </td>
                </tr>
            </table>
            <div className="analysis" hidden={response==undefined || response.totalPasses == -1}>
                <h2>Solution</h2>
                
                <Puzzle Grid={response.solvedPuzzle}></Puzzle>

                <h2>Moves</h2>
                <MovesTable Moves={response.moves} />
            </div>
        </div>

        <ErrorDisplay Errors={errors} />
    </div>
    );
}