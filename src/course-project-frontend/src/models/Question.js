class Question {
    constructor(id, templateId, title, description, type, options, displayInResults) {
        this.id = id;
        this.templateId = templateId;
        this.title = title;
        this.description = description;
        this.type = type;
        this.options = options;
        this.displayInResults = displayInResults;
    }
}

export default Question;
