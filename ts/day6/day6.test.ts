import * as reader from "./reader";
import * as day from "./day";
import {run} from "./day6";


describe("Run", () => {
    let initialFish = [
        {
            amountOfFishRepresented: 1,
            daysUntilNewFish: 0
        },
        {
            amountOfFishRepresented: 1,
            daysUntilNewFish: 0
        }
    ];
    let readFish = jest.spyOn(reader, "readFish").mockReturnValueOnce(initialFish);

    let dayOneFish = [
        {amountOfFishRepresented: 1, daysUntilNewFish: 1}, {amountOfFishRepresented: 1, daysUntilNewFish: 2}
    ];
    let dayTwoFish = [
        {amountOfFishRepresented: 1, daysUntilNewFish: 3}, {amountOfFishRepresented: 1, daysUntilNewFish: 4}
    ];
    let dayThreeFish = [
        {amountOfFishRepresented: 1, daysUntilNewFish: 5}, {
            amountOfFishRepresented: 1,
            daysUntilNewFish: 6
        }, {amountOfFishRepresented: 1, daysUntilNewFish: 6}, {amountOfFishRepresented: 1, daysUntilNewFish: 6}
    ];
    let executeDay = jest.spyOn(day, "executeDay")
        .mockReturnValueOnce(dayOneFish)
        .mockReturnValueOnce(dayTwoFish)
        .mockReturnValueOnce(dayThreeFish)

    it("should read the given file then execute a day for each day needed to pass then return the count of fish returned the last day", () => {
        let expectedFilePath = "someFilePath.txt";
        let result = run(expectedFilePath, 3);

        expect(readFish.mock.calls.length).toBe(1);
        expect(readFish.mock.calls[0][0]).toBe(expectedFilePath);

        expect(executeDay.mock.calls.length).toBe(3);
        expect(executeDay.mock.calls[0][0]).toBe(initialFish);
        expect(executeDay.mock.calls[1][0]).toBe(dayOneFish);
        expect(executeDay.mock.calls[2][0]).toBe(dayTwoFish);

        expect(result).toBe(dayThreeFish.length);
    });
});


describe("Run the input", () => {
    it("should read the given file then execute a day for each day needed to pass then return the count of fish returned the last day", () => {
        let result = run('day6/testInput.txt', 80);
        expect(result).toBe(5934);
    });

    it("should calculate part two", () => {
        let result = run('day6/testInput.txt', 256);
        expect(result).toBe(26984457539);
    });

    it("should run my days input", () => {
        let result = run('day6/day6Input.txt', 80);
        expect(result).toBe(352195);
    });

    it("should run my days input against part two", () => {
        let result = run('day6/day6Input.txt', 256);
        expect(result).toBe(1600306001288);
    });
});
