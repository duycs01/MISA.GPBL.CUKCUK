import Enum from './enum'
class ValidateData {
  constructor() { }

  /**
   * Kiểm tra 2 object bằng nhau
     * CreatedBy: duylv - 09/10/2021
   */
  checkObjEqual(object1, object2) {
    try {
      const keys1 = Object.keys(object1);
      const keys2 = Object.keys(object2);
      if (keys1.length !== keys2.length) {
        return false;
      }
      for (const key of keys1) {
        const val1 = object1[key];
        const val2 = object2[key];
        if (val1 != val2) {
          return false;
        }
      }
      return true;
    } catch (error) {
      console.log(error);
    }
  }

  checkStatusApi(status) {
    switch (status.IsValid) {
      case true:
        return { mess: status.Messenger.userMsg, icon: Enum.IconPopup.Success }
      case false:
        return { mess: status.Messenger.userMsg, icon: Enum.IconPopup.Error }
      default:
        return { mess: status.Messenger.userMsg, icon: Enum.IconPopup.Error }
    }
  }
}

export default new ValidateData()