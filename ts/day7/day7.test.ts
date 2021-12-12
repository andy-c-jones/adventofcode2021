import {run} from "./day7";

describe("median", () => {

    let cases = [
        {filePath: "day7/testInput.txt", expected: 37},
        {filePath: "day7/day7Input.txt", expected: 354129},
    ];

    for (const input of cases) {
        it("should return ", () => {
            let actual = run(input.filePath);
            expect(actual).toBe(input.expected);
        });
    }
});

