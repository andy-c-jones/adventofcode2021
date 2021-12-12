import {runPartOne, runPartTwo} from "./day7";

describe("runPartOne", () => {

    let cases = [
        {filePath: "day7/testInput.txt", expected: 37},
        {filePath: "day7/day7Input.txt", expected: 354129},
    ];

    for (const input of cases) {
        it("should return answer to part one", () => {
            let actual = runPartOne(input.filePath);
            expect(actual).toBe(input.expected);
        });
    }
});

describe("runPartTwo", () => {

    let cases = [
        {filePath: "day7/testInput.txt", expected: 168},
        {filePath: "day7/day7Input.txt", expected: 98905973},
    ];

    for (const input of cases) {
        it("should return answer to part two", () => {
            let actual = runPartTwo(input.filePath);
            expect(actual).toBe(input.expected);
        });
    }
});

