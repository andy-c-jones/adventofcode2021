import {calculate} from "./crabs";

describe("median", () => {

    let cases = [
        {numbers: [16, 1, 2, 0, 4, 2, 7, 1, 2, 14], expected: 37},
        {numbers: [10, 12, 12, 23, 33, 34, 321, 453, 453, 675], expected: 1846},
    ];

    for (const input of cases) {
        it("should return ", () => {
            let actual = calculate(input.numbers);
            expect(actual).toBe(input.expected);
        });
    }
});

