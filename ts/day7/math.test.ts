import {median} from "./math";

describe("median", () => {

    let cases = [
        {numbers: [16, 1, 2, 0, 4, 2, 7, 1, 2, 14], expected: 2},
        {numbers: [1, 2, 3], expected: 2},
        {numbers: [1, 2], expected: 1.5},
        {numbers: [10, 12, 23, 321, 453, 675], expected: 172},
        {numbers: [10, 12, 12, 23, 33, 34, 321, 453, 453, 675], expected: 33.5},
    ];

    for (const input of cases) {
        it("should return median", () => {
            let actual = median(input.numbers);
            expect(actual).toBe(input.expected);
        });
    }
});


