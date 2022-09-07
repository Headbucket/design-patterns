from viewer import Viewer

class ViewerTotal(Viewer):

    def get_output_string(self, value):
        return "Total value: {}".format(value)