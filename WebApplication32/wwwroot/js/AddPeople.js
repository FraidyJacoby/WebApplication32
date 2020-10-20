$(() => {

    let counter = 0;

    $(`#first-name-${counter}`).focus;

    $("#add-button").on('click', function () {
        $("#my-form").append(buildHtml());
    })

    function buildHtml() {
        counter++;
        $("#submit-button").remove();
        return `<div class="col-md-5">
                <input id="first-name-${counter}" type="text" class="form-control" name="ppl[${counter}].firstName" placeholder="First name" />
                </div>

                <div class="col-md-5">
                    <input type="text" class="form-control" name="ppl[${counter}].lastName" placeholder="Last name" />
                </div>
                <div class="col-md-2">
                    <input type="text" class="form-control" name="ppl[${counter}].age" placeholder="Age" />
                </div>
                <button id="submit-button" style="margin-top:25px;" class="btn btn-success">Submit</button>`;
    }
})