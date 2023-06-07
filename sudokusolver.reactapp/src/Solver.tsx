import { useState } from "react"
import { SudokuAnalyticsResponse } from "./models/SudokuAnalyticsResponse";
import {callSolve} from './services/Api'
import "./styles/Solver.css"
import "./styles/Button.css"
import Puzzle from "./components/Puzzle";
import {MapSolverStrategyToString} from "./mappers/SolverStrategyTypeMapper"

export function Solver(){
    const [input, setInput] = useState('')
    const [response, setResponse] = useState(new SudokuAnalyticsResponse());

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
                            onClick={async (e)=>{
                                let result: any = await callSolve(input);
                                let hardResponse: SudokuAnalyticsResponse = result.data.data;
                                setResponse(hardResponse);
                            }}
                        >
                            Solve
                        </button>
                    </td>
                </tr>
            </table>
            <div className="analysis" hidden={response.totalPasses == -1}>
                <h2>Solution</h2>
                
                <Puzzle Grid={response.solvedPuzzle2D}></Puzzle>
                <h2>Moves</h2>
                <table className="moves">
                    <th>Order</th>
                    <th>Strategy</th>
                    <th>Value</th>
                    <th>Row</th>
                    <th>Column</th>
                    {response.moves.map((m)=> 
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
                    )}
                </table>
            </div>
        </div>
    </div>
    );
}