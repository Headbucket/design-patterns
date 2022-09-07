import glob
import re
import os
import codecs

def main():
    files = glob.glob("./**/README.md", recursive = True)
    for file in files:
        update(file)

def update(file):
    print('Updating', file)
    lines = read_file(file)
    update_list = scan_lines(file, lines)    
    if len(update_list) > 0:
        lines = update_lines(lines, update_list)        
        write_file(file, lines)                

def read_file(file):
    f = open(file, 'r')
    lines = f.readlines()
    f.close()
    return lines

def write_file(file, lines):
    f = open(file, 'w')
    f.writelines(lines)
    f.close()

def scan_lines(file, lines):
    result = []
    current_start_index = -1    
    for index, line in enumerate(lines):
        x = re.search('^```.* (.*)$', line)
        if x != None:
            current_start_index = index
            code_file = x.groups()[0]
            code_file = os.path.join(os.path.dirname(os.path.abspath(file)), 
                        code_file)
            continue
        x = re.search('^```$', line)
        if (x != None) and (current_start_index != -1):
            result.append({'start_index': current_start_index, 
                           'end_index': index, 
                           'code_file': code_file})
            current_start_index = -1                
    return result

def update_lines(lines, update_list):   
    for item in reversed(update_list):
        if os.path.exists(item['code_file']): 
            encoding = detect_by_bom(item['code_file'], 'utf-8')
            f = open(item['code_file'], 'r', encoding=encoding) 
            code_lines = f.readlines()
            f.close()             

            code_lines = remove_empty_lines_at_end(code_lines)

            if len(code_lines) > 0:
                if code_lines[-1][-1] != '\n':
                    code_lines[-1] += '\n'    
            
                lines[item['start_index']+1:item['end_index']] = code_lines            

        print(item) 
    return lines

def remove_empty_lines_at_end(code_lines):
    for index, code_line in reversed(list(enumerate(code_lines))):        
        if code_line.strip() == '':
            del code_lines[index]
        else:
            break
    return code_lines

def detect_by_bom(file, default_encoding):
    with open(file, 'rb') as f:
        raw = f.read(4)
    for enc, boms in \
            ('utf-8-sig', (codecs.BOM_UTF8,)), \
            ('utf-32', (codecs.BOM_UTF32_LE, codecs.BOM_UTF32_BE)), \
            ('utf-16', (codecs.BOM_UTF16_LE, codecs.BOM_UTF16_BE)):
        if any(raw.startswith(bom) for bom in boms):
            return enc
    return default_encoding

if __name__ == '__main__':
    main()