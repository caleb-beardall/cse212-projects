using System.Windows.Markup;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Create a queue with the following items: Value: Low (Priority: 1), Value: Medium (Priority: 2), Value: High (Priority: 3), 
    // and Value: Urgent (Priority: 4). Then, dequeue each item from the queue in the correct priority order.
    // Expected Result: Urgent, High, Medium, Low
    // Defect(s) Found: The two defects that resulted in the failure of this test were that 1) Dequeue did not remove the item it
    // determined should be removed from the queue next and 2) the for loop in Dequeue wasn't checking the last item in the queue.
    public void TestPriorityQueue_1()
    {
        var low = new PriorityItem("Low", 1);
        var medium = new PriorityItem("Medium", 2);
        var high = new PriorityItem("High", 3);
        var urgent = new PriorityItem("Urgent", 4);

        PriorityItem[] expectedResult = [urgent, high, medium, low];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(low.Value, low.Priority);
        priorityQueue.Enqueue(urgent.Value, urgent.Priority);
        priorityQueue.Enqueue(medium.Value, medium.Priority);
        priorityQueue.Enqueue(high.Value, high.Priority);

        int i = 0;
        while (priorityQueue.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var item = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, item);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Create a queue with the following items: Value: Low1 (Priority: 1), Value: Urgent1 (Priority: 4), Value: Medium1 (Priority: 2), Value: High1 (Priority: 3),
    // Value: Low2 (Priority: 1), Value: Urgent2 (Priority: 4), Value: Medium2 (Priority: 2), and Value: High2 (Priority: 3). (Note that priority levels are distributed through the queue.
    // Then, dequeue each item from the queue in the correct order of priority. Of the values that share priority levels, values that end with a 1 should be dequeued before the values
    // that end with a 2 because they were enqueued first.
    // Expected Result: Urgent1, Urgent2, High1, High2, Medium1, Medium2, Low1, Low2
    // Defect(s) Found: This test failed for the same reasons the one above did. In addition to that, the if statement in Dequeued incorrectly handled dequeing items of the same priority.
    // When dealing with items of the same priority, it would replace the first enqueued item with the second because the condition used ">=" when it should have just use ">".
    public void TestPriorityQueue_2()
    {
        var low1 = new PriorityItem("Low", 1);
        var low2 = new PriorityItem("Low", 1);
        var medium1 = new PriorityItem("Medium", 2);
        var medium2 = new PriorityItem("Medium", 2);
        var high1 = new PriorityItem("High", 3);
        var high2 = new PriorityItem("High", 3);
        var urgent1 = new PriorityItem("Urgent", 4);
        var urgent2 = new PriorityItem("Urgent", 4);

        PriorityItem[] expectedResult = [urgent1, urgent2, high1, high2, medium1, medium2, low1, low2];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue(low1.Value, low1.Priority);
        priorityQueue.Enqueue(urgent1.Value, urgent1.Priority);
        priorityQueue.Enqueue(medium1.Value, medium1.Priority);
        priorityQueue.Enqueue(high1.Value, high1.Priority);
        priorityQueue.Enqueue(low2.Value, low2.Priority);
        priorityQueue.Enqueue(urgent2.Value, urgent2.Priority);
        priorityQueue.Enqueue(medium2.Value, medium2.Priority);
        priorityQueue.Enqueue(high2.Value, high2.Priority);

        int i = 0;
        while (priorityQueue.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var item = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, item);
            i++;
        }
    }

    [TestMethod]
    // Scenario: Tries to dequeue a value from the queue when its empty.
    // Expected Result: An InvalidOperationException should be thrown with the message
    // "The queue is empty."
    // Defect(s) Found: None found. The requirements were implemented correctly.
    public void TestPriorityQueue_3()
    {
        var values = new PriorityQueue();

        try
        {
            values.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch(Exception e)
        {
            Assert.Fail(
                string.Format("Unexpected exception of type {0} caught: {1}",
                    e.GetType(), e.Message)
            );
        }
    }
}