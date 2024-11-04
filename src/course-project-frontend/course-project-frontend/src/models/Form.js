class Form {
    constructor(id = null, userId, templateId, dateSubmitted) {
      this.id = id; // Nullable, defaulting to null
      this.userId = userId;
      this.templateId = templateId;
      this.dateSubmitted = dateSubmitted;
    }
}
  
export default Form;