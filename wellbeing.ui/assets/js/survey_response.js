$(document).ready((doc) => {
    $(".question-input-option").on("change", (e) => {
        const jqInputOption = $(e.target);
        // console.log(jqInputOption.val()) This is the value (answer)
        // console.log(jqInputOption.data("questionId")) This is the question Id for selected option
        const data = {
            "QuestionId": parseInt(jqInputOption.data("questionId")),
            "Score": parseInt(jqInputOption.val())
        };

        $.ajax({
            type: "POST",
            url: "/questions/submit",
            data: JSON.stringify(data),
            success: () => console.log("foo"),
            contentType: "application/json",
            dataType: "json"
          });

        jqInputOption.parents(".question-container").remove()
    })
});