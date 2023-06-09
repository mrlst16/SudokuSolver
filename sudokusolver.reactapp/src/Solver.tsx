import { useState } from "react"
import { SudokuAnalyticsResponse } from "./models/SudokuAnalyticsResponse";
import {callSolve} from './services/Api'
import "./styles/Solver.css"
import "./styles/Button.css"
import Puzzle from "./components/Puzzle";
import {MapSolverStrategyToString} from "./mappers/SolverStrategyTypeMapper"
import { ApiResponse } from "./models/ApiResponse";
import { ApiError } from "./models/ApiError";
import ErrorDisplay from "./components/ErrorDisplay";
import { ApiErrors } from "./models/ApiErrors";

export function Solver(){
    const [input, setInput] = useState('')
    const [response, setResponse] = useState(new SudokuAnalyticsResponse());
    const [errors, setErrors] = useState(new ApiErrors());

    function HandleSolveButtonClick(){
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
                        <textarea
                            className="input"                
                            onChange={
                                (e)=> {
                                    setInput(e.target.value)
                                }
                            }
                            />
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
                <table className="moves">
                    <th>Order</th>
                    <th>Strategy</th>
                    <th>Value</th>
                    <th>Row</th>
                    <th>Column</th>
                    {
                            response.moves.map((m)=> 
                            <tr>
                                <td>{m.order}</td>
                                <td>{
                                        MapSolverStrategyToString(m.type)
                                    }
                                </td>
                                <td>{m.value}</td>
                                <td>{m.i}</td>
                                <td>{m.j}</td>
                            </tr>
                        )
                    }
                </table>
            </div>
        </div>

        <ErrorDisplay Errors={errors} />
    </div>
    );
}